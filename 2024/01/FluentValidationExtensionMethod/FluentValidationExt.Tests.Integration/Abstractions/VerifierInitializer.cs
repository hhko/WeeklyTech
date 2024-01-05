using System.Runtime.CompilerServices;

namespace FluentValidationExt.Tests.Integration.Abstractions;

public static class VerifierInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // https://github.com/VerifyTests/Verify/blob/main/docs/naming.md
        // UseSplitModeForUniqueDirectory 
        UseProjectRelativeDirectory("Snapshots");

        //VerifySourceGenerators.Enable();
    }
}
