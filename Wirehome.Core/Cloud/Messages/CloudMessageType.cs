﻿namespace Wirehome.Core.Cloud.Messages
{
    public static class CloudMessageType
    {
        public const string Ping = "wirehome.cloud.message.ping";

        public const string HttpInvoke = "wirehome.cloud.message.http_invoke";

        public const string Raw = "wirehome.cloud.message.raw";

        public const string Error = "wirehome.cloud.message.error";
    }
}
