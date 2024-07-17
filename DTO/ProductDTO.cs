namespace WorldImporters.DTO;

public record ProductDTO(
    int ProductId,
    string ProductName,
    int? SupplierId,
    string SupplierName,
    int? CategoryId,
    string CategoryName,
    string? QuantityPerUnit,
    decimal? UnitPrice,
    short? UnitsInStock,
    short? UnitsOnOrder,
    short? ReorderLevel,
    bool Discontinued);
