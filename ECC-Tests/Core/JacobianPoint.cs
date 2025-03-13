using System;
using Eduard;
#pragma warning disable

namespace ECC_Tests.Core
{
    /* Represents a projective Jacobian point (x, y, z) that maps to affine elliptic curve point (x/z^2, y/z^3) */
    public class JacobianPoint
    {
        public BigInteger x { get; set; }
        public BigInteger y { get; set; }
        public BigInteger z { get; set; }

        public static JacobianPoint POINT_INFINITY
        {
            get
            {
                /* Represents the point at infinity to the Weierstrass curve */
                return new JacobianPoint
                {
                    x = 1,
                    y = 1,
                    z = 0
                };
            }
        }
    }
}
