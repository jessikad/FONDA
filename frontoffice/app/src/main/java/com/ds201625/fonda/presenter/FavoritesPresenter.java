package com.ds201625.fonda.presenter;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.IFavoriteView;
import com.ds201625.fonda.interfaces.IFavoriteViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 * Presentador para obtener todos los favoritos
 */
public class FavoritesPresenter implements IFavoriteViewPresenter {

    private IFavoriteView iFavoriteView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private List<Restaurant> listRestWS;
    private String TAG = "FavoritesPresenter";

    /**
     * Constructor
     * @param view
     */
    public FavoritesPresenter(IFavoriteView view){
        iFavoriteView = view;
    }

    /**
     * Encuentra el comensal logueado
     */
    @Override
    public void findLoggedComensal() {
        Log.d(TAG,"Ha entrado en findLoggedComensal");
        Commensal log = SessionData.getInstance().getCommensal();

        emailToWebService=log.getEmail()+"/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0,emailToWebService);
            cmdRequireLoged.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }

        logedComensal = (Commensal) cmdRequireLoged.getResult();
        Log.d(TAG,"Se obtiene el comensal logueado "+logedComensal.getId());
        Log.d(TAG,"Ha finalizado findLoggedComensal");
    }


    /**
     * Encuentra los restaurantes favoritos
     *
     * @return
     */
    @Override
    public List<Restaurant> findAllFavoriteRestaurant() {
        Log.d(TAG,"Ha entrado en findAllFavoriteRestaurant");
        Command cmdAllFavorite = facCmd.allFavoriteRestaurantCommand();
        try {
            cmdAllFavorite.setParameter(0,logedComensal);
            cmdAllFavorite.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findAllFavoriteRestaurant al buscar los restaurantes favoritos",
                    e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error en findAllFavoriteRestaurant al buscar los restaurantes favoritos",
                    e);
        }
        listRestWS = (List<Restaurant>) cmdAllFavorite.getResult();
        Log.d(TAG,"Se retorna la lista de Restaurantes Favoritos");
        Log.d(TAG,"Ha finalizado findAllFavoriteRestaurant");
        return listRestWS;
    }

    /**
     * Elimina el restaurante seleccionado
     *
     * @param restaurant
     */
    @Override
    public void deleteFavoriteRestaurant(Restaurant restaurant) {
        Log.d(TAG,"Ha entrado en deleteFavoriteRestaurant");
        Command cmdDelete = facCmd.deleteFavoriteRestaurantCommand();
        try {
            cmdDelete.setParameter(0,logedComensal);
            cmdDelete.setParameter(1,restaurant);
            cmdDelete.run();
        }
        catch (NullPointerException e){
            Log.e(TAG,"Error en deleteFavoriteRestaurant al eliminar un restaurante favorito",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en deleteFavoriteRestaurant al eliminar un restaurante favorito",
                    e);
        }
        Log.d(TAG,"Se elimina el restaurante de favoritos "+restaurant.getName());
        Log.d(TAG,"Ha finalizado deleteFavoriteRestaurant");
    }

    /**
     * Agrega un restaurante a favoritos
     *
     * @param restaurant
     */
    @Override
    public void addFavoriteRestaurant(Restaurant restaurant) {
        Log.d(TAG,"Ha entrado en addFavoriteRestaurant");
        Command cmdAddFavorite = facCmd.addFavoriteRestaurantCommand();
        try {
            cmdAddFavorite.setParameter(0,logedComensal);
            cmdAddFavorite.setParameter(1,restaurant);
            cmdAddFavorite.run();

        } catch (NullPointerException e){
            Log.e(TAG,"Error en addFavoriteRestaurant al agregar un restaurante a favoritos",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en addFavoriteRestaurant al agregar un restaurante a favoritos",
                    e);
        }
        Log.d(TAG,"Se agrega el restaurante a favoritos "+restaurant.getName());
        Log.d(TAG,"Ha finalizado addFavoriteRestaurant");
    }



}
