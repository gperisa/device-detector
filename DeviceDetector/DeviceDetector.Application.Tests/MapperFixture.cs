using AutoMapper;
using DeviceDetector.Application.Mapping;
using System;
using System.Linq;

namespace DeviceDetector.Application.Tests
{
    public class MapperFixture
    {
        public IMapper CreateMapper()
        {
            var profiles =
                from t in typeof(DeviceInfoProfile).Assembly.GetTypes()
                where typeof(Profile).IsAssignableFrom(t)
                select (Profile)Activator.CreateInstance(t);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            return config.CreateMapper();
        }
    }
}
