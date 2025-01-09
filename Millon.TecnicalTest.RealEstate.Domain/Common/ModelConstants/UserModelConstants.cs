namespace Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants
{
    public class UserModelConstants
    {
        public class Usuario
        {
            public const int MinIdLength = 5;
            public const int MaxIdLength = 50;

            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
            public const int MinPhoneLength = 5;
            public const int MaxPhoneLength = 20;
        }

        public class Direccion
        {
            public const int MinNameLength = 5;
            public const int MaxNameLength = 100;
        }
    }
}
