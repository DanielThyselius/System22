using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageHandler.Tests
{
    [CollectionDefinition(nameof(PackageCollection))]
    public class PackageCollection : ICollectionFixture<PackageFixture>
    {
    }
}
