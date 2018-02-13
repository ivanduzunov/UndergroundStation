namespace UndergroundStation.Test
{
    using AutoMapper;
    using UndergroundStation.Web.Infrastructure.Mapping;

    public class TestStartUp
    {
        private static bool TestInitialized = false;

        public static void Initialize()
        {
            if (!TestInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

                TestInitialized = true;
            }
        }
    }
}
