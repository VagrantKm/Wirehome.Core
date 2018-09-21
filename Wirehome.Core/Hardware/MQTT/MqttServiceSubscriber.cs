﻿using System;
using MQTTnet;
using MQTTnet.Server;

namespace Wirehome.Core.Hardware.MQTT
{
    public class MqttServiceSubscriber
    {
        private readonly string _topicFilter;
        private readonly Action<MqttApplicationMessageReceivedEventArgs> _callback;

        public MqttServiceSubscriber(string uid, string topicFilter, Action<MqttApplicationMessageReceivedEventArgs> callback)
        {
            Uid = uid ?? throw new ArgumentNullException(nameof(uid));
            _topicFilter = topicFilter ?? throw new ArgumentNullException(nameof(topicFilter));
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        public string Uid { get; }

        public bool IsFilterMatch(MqttApplicationMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            return MqttTopicFilterComparer.IsMatch(message.Topic, _topicFilter);
        }

        public void Notify(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            if (eventArgs == null) throw new ArgumentNullException(nameof(eventArgs));

            _callback(eventArgs);
        }
    }
}
