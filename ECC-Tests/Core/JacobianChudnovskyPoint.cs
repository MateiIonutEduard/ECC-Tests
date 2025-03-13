using System;
using Eduard;
#pragma warning disable

namespace ECC_Tests.Core
{
    /* Represents a Jacobian Chudnovsky projective point (x, y, z, z^2, z^3) that maps to affine elliptic curve point (x/z^2, y/z^3) */
    public class JacobianChudnovskyPoint : JacobianPoint
    {
        public BigInteger z2 { get; set; }
        public BigInteger z3 { get; set; }

        public static JacobianChudnovskyPoint POINT_INFINITY
        {
            get
            {
                /* Represents the point at infinity to the Weierstrass curve */
                return new JacobianChudnovskyPoint
                {
                    x = 1,
                    y = 1,
                    z = 0,
                    z2 = 0,
                    z3 = 0
                };
            }
        }
    }
}
