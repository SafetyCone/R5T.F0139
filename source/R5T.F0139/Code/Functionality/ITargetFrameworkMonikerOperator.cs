using System;

using R5T.T0132;
using R5T.T0218;
using R5T.T0219;


namespace R5T.F0139
{
    [FunctionalityMarker]
    public partial interface ITargetFrameworkMonikerOperator : IFunctionalityMarker
    {
        public IDotnetMajorVersion Get_DotnetMajorVersion(ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var output = targetFrameworkMoniker.Value switch
            {
                Z0057.ITargetFrameworkMonikers.NET_6_Constant => Instances.DotnetMajorVersions.V6,
                _ => throw new Exception($"Unknown target framework moniker: {targetFrameworkMoniker}")
            };

            return output;
        }
    }
}
