/* Autogenerated file. Manual edits will not be saved.*/

#nullable enable
using System;
using mud.Client;
using mud.Network.schemas;
using mud.Unity;
using UniRx;
using Property = System.Collections.Generic.Dictionary<string, object>;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CounterTableUpdate : TypedRecordUpdate<Tuple<CounterTable?, CounterTable?>> { }

    public class CounterTable : IMudTable
    {
        public readonly static TableId ID = new("", "Counter");

        public override TableId GetTableId()
        {
            return ID;
        }

        public ulong? value;

        public override Type TableType()
        {
            return typeof(CounterTable);
        }

        public override Type TableUpdateType()
        {
            return typeof(CounterTableUpdate);
        }

        public override void SetValues(params object[] functionParameters)
        {
            value = (ulong)(int)functionParameters[0];
        }

        public override bool SetValues(IEnumerable<Property> result)
        {
            var hasValues = false;
            foreach (var record in result)
            {
                var attribute = record["attribute"].ToString();
                var value = record["value"];

                switch (attribute)
                {
                    case "value":
                        var valueValue = (ulong)value;
                        value = valueValue;
                        hasValues = true;
                        break;
                }
            }

            return hasValues;
        }

        public override IMudTable GetTableValue(string key)
        {
            var query = new Query()
                .Find("?value", "?attribute")
                .Where(TableId.ToString(), key, "?attribute", "?value");
            var result = NetworkManager.Instance.ds.Query(query);
            var counterTable = new CounterTable();
            var hasValues = false;

            foreach (var record in result)
            {
                var attribute = record["attribute"].ToString();
                var value = record["value"];

                switch (attribute)
                {
                    case "value":
                        var valueValue = (ulong)value;
                        counterTable.value = valueValue;
                        hasValues = true;
                        break;
                }
            }

            return hasValues ? counterTable : null;
        }

        public override IMudTable RecordUpdateToTable(RecordUpdate tableUpdate)
        {
            CounterTableUpdate update = (CounterTableUpdate)tableUpdate;

            var currentValue = update?.TypedValue.Item1;
            if (currentValue == null)
            {
                Debug.LogError("No value on CounterTable update");
            }

            return currentValue;
        }

        public override RecordUpdate CreateTypedRecord(RecordUpdate newUpdate)
        {
            return new CounterTableUpdate
            {
                TableId = newUpdate.TableId,
                Key = newUpdate.Key,
                Value = newUpdate.Value,
                TypedValue = MapUpdates(newUpdate.Value)
            };
        }

        public static Tuple<CounterTable?, CounterTable?> MapUpdates(
            Tuple<Property?, Property?> value
        )
        {
            CounterTable? current = null;
            CounterTable? previous = null;

            if (value.Item1 != null)
            {
                try
                {
                    current = new CounterTable
                    {
                        value = value.Item1.TryGetValue("value", out var valueVal)
                            ? (ulong)valueVal
                            : default,
                    };
                }
                catch (InvalidCastException)
                {
                    current = new CounterTable { value = null, };
                }
            }

            if (value.Item2 != null)
            {
                try
                {
                    previous = new CounterTable
                    {
                        value = value.Item2.TryGetValue("value", out var valueVal)
                            ? (ulong)valueVal
                            : default,
                    };
                }
                catch (InvalidCastException)
                {
                    previous = new CounterTable { value = null, };
                }
            }

            return new Tuple<CounterTable?, CounterTable?>(current, previous);
        }
    }
}
