package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.clients.RestaurantClient;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Zone;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

public class RetrofitRestaurantService implements RestaurantService {

    private RestaurantClient resClient;

    @Override
    public List<RestaurantCategory> getCategories(String query, int max, int page){
        Call<List<RestaurantCategory>> call = resClient.getCategories(query, max, page);
        List<RestaurantCategory> categories = null;

        try {
            categories = call.execute().body();
        } catch (IOException e) {

        }

        return categories;
    }

    @Override
    public List<Zone> getZones(String query, int max, int page) {
        Call<List<Zone>> call = resClient.getZones(query, max, page);
        List<Zone> zones = null;

        try {
            zones = call.execute().body();
        } catch (IOException e) {

        }

        return zones;
    }

    @Override
    public List<Restaurant> getRestaurants(String query, int max, int page, String category, String zone) {
        Call<List<Restaurant>> call = resClient.getRestaurants(query, max, page, category, zone);
        List<Restaurant> restaurants = null;

        try {
            restaurants = call.execute().body();
        } catch (IOException e) {

        }

        return restaurants;
    }
}