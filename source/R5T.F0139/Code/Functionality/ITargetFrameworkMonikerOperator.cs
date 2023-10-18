using System;

using R5T.T0132;
using R5T.T0218;
using R5T.T0219;

using ITargetFrameworkMonikers = R5T.Z0057.Platform.ITargetFrameworkMonikers;


namespace R5T.F0139
{
    [FunctionalityMarker]
    public partial interface ITargetFrameworkMonikerOperator : IFunctionalityMarker
    {
        public IDotnetMajorVersion Get_DotnetMajorVersion(ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            // Deal with "net6.0-windows" for example.
            var isSuffixed = Instances.StringOperator.Contains(
                targetFrameworkMoniker.Value,
                Instances.Characters.Dash);

            var ensuredTargetFrameworkMoniker = isSuffixed
                ? Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    Instances.StringOperator.Get_IndexOf(
                        targetFrameworkMoniker.Value,
                        Instances.Characters.Dash),
                    targetFrameworkMoniker.Value)
                : targetFrameworkMoniker.Value
                ;

            var output = ensuredTargetFrameworkMoniker switch
            {
                ITargetFrameworkMonikers.NET_5_Constant => Instances.DotnetMajorVersions.V5,
                ITargetFrameworkMonikers.NET_6_Constant => Instances.DotnetMajorVersions.V6,
                ITargetFrameworkMonikers.NET_App_2_2_Constant => Instances.DotnetMajorVersions.V2,
                ITargetFrameworkMonikers.Net_Standard2_0_Constant => Instances.DotnetMajorVersions.V2,
                ITargetFrameworkMonikers.Net_Standard2_1_Constant => Instances.DotnetMajorVersions.V2,
                _ => throw new Exception($"Unknown target framework moniker: {targetFrameworkMoniker}")
            };

            return output;
        }
    }
}
