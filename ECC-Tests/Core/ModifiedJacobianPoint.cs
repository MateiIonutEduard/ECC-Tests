using System;
using Eduard;
#pragma warning disable

namespace ECC_Tests.Core
{
    public class ModifiedJacobianPoint : JacobianPoint
    {
        public BigInteger aZ4 { get; set; }
        public static ModifiedJacobianPoint POINT_INFINITY { 
            get
            {
                return new ModifiedJacobianPoint
                {
                    x = 1,
                    y = 1,
                    z = 0,
                    aZ4 = 0
                };
            }
        }
    }
}
