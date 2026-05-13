using Bull.Ga.Common.AppModels;
using Microsoft.Extensions.Options;
using System.Net;

namespace Bull.Ga.Api.Helpers
{
    public class SwaggerRestrictionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public SwaggerRestrictionMiddleware(
            RequestDelegate next,
            IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                var remoteIp = context.Connection.RemoteIpAddress;

                // 🔒 IP Restriction
                if (!IsAllowed(remoteIp))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Forbidden");
                    return;
                }
            }

            await _next(context);
        }

        private bool IsAllowed(IPAddress? remoteIp)
        {
            if (remoteIp == null)
                return false;

            var ip = remoteIp.ToString();

            if (_appSettings.AllowedIps.Contains(ip))
                return true;

            return _appSettings.AllowedSubnets.Any(subnet => IsInSubnet(remoteIp, subnet));
        }

        private bool IsInSubnet(IPAddress address, string subnetMask)
        {
            var parts = subnetMask.Split('/');
            var baseAddress = IPAddress.Parse(parts[0]);
            int prefixLength = int.Parse(parts[1]);

            var addressBytes = address.GetAddressBytes();
            var baseBytes = baseAddress.GetAddressBytes();

            int bytes = prefixLength / 8;
            int bits = prefixLength % 8;

            for (int i = 0; i < bytes; i++)
            {
                if (addressBytes[i] != baseBytes[i])
                    return false;
            }

            if (bits > 0)
            {
                int mask = (byte)~(255 >> bits);
                if ((addressBytes[bytes] & mask) != (baseBytes[bytes] & mask))
                    return false;
            }

            return true;
        }
    }
}
