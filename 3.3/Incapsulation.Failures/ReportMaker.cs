using System;
using System.Collections.Generic;
using System.Linq;

namespace Incapsulation.Failures
{
	public class Device
	{
		public int Id { get; }
		public string Name { get; }

		public Device(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}

	public enum FailureType
	{
		Shutdown = 0,
		NonResponding = 1,
		Hardware = 2,
		Connection = 3
	}

	public class Failure
	{
		public int DeviceId { get; }

		private readonly FailureType _failureType;
		private readonly DateTime _time;

		public Failure(int type, DateTime time, int deviceId)
		{
			DeviceId = deviceId;

			_time = time;
			_failureType = (FailureType) type;
		}

		public int IsFailureSerious()
		{
			return (int) _failureType % 2 == 0 ? 1 : 0;
		}

		public bool IsBeforeDate(DateTime date)
		{
			return _time < date;
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

			var failureList = new List<Failure>();

			for (var i = 0; i < failureTypes.Length; i++)
			{
				var time = new DateTime((int) times[i][2], (int) times[i][1], (int) times[i][0]);
				failureList.Add(new Failure(failureTypes[i], time, deviceId[i]));
			}

			var deviceList = devices
				.Select(device => new Device((int) device["DeviceId"], (string) device["Name"]))
				.ToList();

			return FindDevicesFailedBeforeDate(date, failureList, deviceList);
		}

		public static List<string> FindDevicesFailedBeforeDate
			(DateTime date, List<Failure> failures, List<Device> devices)
		{
			var result = new List<Device>();

			foreach (var failure in failures)
				if (failure.IsFailureSerious() == 1 && failure.IsBeforeDate(date))
					result.Add(devices.Find(d => d.Id == failure.DeviceId));

			return result.Select(r => r.Name).ToList();
		}
	}
}