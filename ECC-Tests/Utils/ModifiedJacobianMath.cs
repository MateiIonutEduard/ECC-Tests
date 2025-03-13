using Eduard;
using ECC_Tests.Core;
using System.Runtime.InteropServices.JavaScript;
#pragma warning disable

namespace ECC_Tests.Utils
{
    /* Cohen–Miyaji–Ono (1998) "Efficient elliptic curve exponentiation using mixed coordinates" */
    public static class ModifiedJacobianMath
    {
        public static ModifiedJacobianPoint Add(EllipticCurve curve, ModifiedJacobianPoint left, ModifiedJacobianPoint right)
        {
            if (left.z == 0) return right;
            if (right.z == 0) return left;

            BigInteger p = curve.field;
            BigInteger ZZ1 = (left.z * left.z) % p;
            BigInteger ZZ2 = (right.z * right.z) % p;

            BigInteger U1 = (left.x * ZZ2) % p;
            BigInteger U2 = (right.x * ZZ1) % p;

            BigInteger S1 = (left.y * right.z * ZZ2) % p;
            BigInteger S2 = (right.y * left.z * ZZ1) % p;

            BigInteger H = (U2 - U1) % p;
            if (H < 0) H += p;

            BigInteger HH = (H * H) % p;
            BigInteger HHH = (H * HH) % p;

            BigInteger r = (S2 - S1) % p;
            if (r < 0) r += p;
            BigInteger V = (U1 * HH) % p;

            BigInteger X = (r * r - HHH - 2 * V) % p;
            if (X < 0) X += p;

            BigInteger Y = (r * (V - X) - S1 * HHH) % p;
            if (Y < 0) Y += p;

            BigInteger Z = (left.z * right.z * H) % p;
            BigInteger ZZ = (Z * Z) % p;
            BigInteger aZ4 = (curve.a * ZZ) % p;

            return new ModifiedJacobianPoint
            {
                x = X,
                y = Y,
                z = Z,
                aZ4 = aZ4
            };
        }

        public static ModifiedJacobianPoint Doubling(EllipticCurve curve, ModifiedJacobianPoint jacobianPoint)
        {
            if (jacobianPoint.z == 0) return ModifiedJacobianPoint.POINT_INFINITY;
            BigInteger p = curve.field;
            BigInteger XX = (jacobianPoint.x * jacobianPoint.x) % p;

            BigInteger YY = (jacobianPoint.y * jacobianPoint.y) % p;
            BigInteger U = (8 * YY * YY) % p;

            BigInteger S = (4 * jacobianPoint.x * YY) % p;
            BigInteger M = (3 * XX + jacobianPoint.aZ4) % p;

            BigInteger X = (M * M - 2 * S) % p;
            if (X < 0) X += p;

            BigInteger Y = (M * (S - X) - U) % p;
            if (Y < 0) Y += p;

            BigInteger Z = (2 * jacobianPoint.y * jacobianPoint.z) % p;
            BigInteger aZ4 = (2 * U * jacobianPoint.aZ4) % p;

            return new ModifiedJacobianPoint
            {
                x = X,
                y = Y,
                z = Z,
                aZ4 = aZ4
            };
        }
    }
}
