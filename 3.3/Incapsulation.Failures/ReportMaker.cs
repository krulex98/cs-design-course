using System;
using System.Collections.Generic;
using System.Linq;

namespace Incapsulation.Failures
{
    public class Device
    {
        private int _id;
        public string Name { get; }

        public Device(int id, string name)
        {
            _id = id;
            Name = name;
        }
    }

    public enum FailureType
    {
        UnexpectedShutdown = 0,
        NonResponding = 1,
        HardwareFailure = 2,
        ConnectionProblems = 3
    }
    
    public class Failure
    {
        private readonly FailureType _failureType;
        
        public Failure(int type)
        {
            _failureType = (FailureType) type;
        }

        public int IsFailureSerious()
        {
            return (int)_failureType % 2 == 0 ? 1 : 0;
        }
    }

    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes"></param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day, int month, int year,
            int[] failureTypes, 
            int[] deviceId, 
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            var date = new DateTime(year, month, day);

            var failureList = failureTypes
                .Select(failureType => new Failure(failureType))
                .ToList();

            var deviceList = devices
                .Select(device => new Device((int) device["DeviceId"], (string) device["Name"]))
                .ToList();

            var timeList = times
                .Select(time => new DateTime((int)time[2], (int)time[1], (int)time[0]))
                .ToList();
            
            return FindDevicesFailedBeforeDate(date, failureList, deviceList, timeList);
        }

        public static List<string> FindDevicesFailedBeforeDate
            (DateTime date, List<Failure> failures, List<Device> devices, List<DateTime> times)
        {
            var result = new List<Device>();
            
            for (var i = 0; i < failures.Count; i++)
                if (failures[i].IsFailureSerious() == 1 && times[i] < date)
                    result.Add(devices[i]);

            return result.Select(r => r.Name).ToList();
        }
    }
}
