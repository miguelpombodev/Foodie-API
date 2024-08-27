using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly DataContext _dataContext;

    public StoreRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<StoreCategory>> GetStoreCategoriesListAsync()
    {
        var storeCategoriesList = await _dataContext.Set<StoreCategory>().ToListAsync();

        return storeCategoriesList;
    }

    public async Task<List<StoreType>> GetStoreTypesListAsync()
    {
        var storeTypesList = await _dataContext.Set<StoreType>().Where(st => st.Avatar != null).ToListAsync();

        return storeTypesList;
    }

    public async Task<List<ListStoreResponseDTO>> GetStoreListAsync(
        string? sortByOptionName,
        decimal? sortByDeliveryFee
    )
    {
        var joinStoresList = _dataContext.Set<Store>().Join(
            _dataContext.Set<StoreType>(),
            store => store.StoreTypeId,
            storeType => storeType.Id,
            (store, storeType) => new
            {
                storeAvatar = store.Avatar,
                storeName = store.Name,
                storeTypeName = storeType.Name,
                storeRate = store.StoreRate,
                storeMinDeliveryTime = store.StoreMinDeliveryTime,
                storeMaxDeliveryTime = store.StoreMaxDeliveryTime,
                storeDeliveryFee = store.StoreDeliveryFee
            }
        );

        if (sortByOptionName != null)
        {
            joinStoresList = sortByOptionName switch
            {
                "sortByRating" => joinStoresList.OrderByDescending(x => x.storeRate),
                "sortByDeliveryFee" => joinStoresList.OrderBy(x => x.storeDeliveryFee),
                "sortByDeliverTime" => joinStoresList.OrderBy(x => x.storeMinDeliveryTime),
                _ => throw new ArgumentOutOfRangeException(nameof(sortByOptionName), sortByOptionName, null)
            };
        }

        if (sortByDeliveryFee != null)
        {
            joinStoresList = joinStoresList.Where(query => query.storeDeliveryFee == sortByDeliveryFee);
        }


        var storesList = await joinStoresList.Select(query =>
                new ListStoreResponseDTO(query.storeAvatar, query.storeName, query.storeTypeName, query.storeRate, query.storeMinDeliveryTime, query.storeMaxDeliveryTime, query.storeDeliveryFee))
            .ToListAsync();

        return storesList;
    }
}