using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using StoreFront.DATA.EF.Models;
using static StoreFront.DATA.EF.Models.ProductMetadata;

namespace StoreFront.DATA.EF.Models
{
    [ModelMetadataType(typeof(CategoryMetadata))]
    public partial class Category { }

    [ModelMetadataType(typeof(OrderMetadata))]
    public partial class Order { }

    [ModelMetadataType(typeof(ProductMetadata))]
    public partial class Product { }

    [ModelMetadataType(typeof(SupplierMetadata))]
    public partial class  Supplier { }

    [ModelMetadataType(typeof(CustomerMetadata))]
    public partial class Customer { }
}
