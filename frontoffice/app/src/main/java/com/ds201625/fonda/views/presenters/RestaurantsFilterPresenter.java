package com.ds201625.fonda.views.presenters;

import android.util.Log;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.UnknownServerErrorException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.ServerErrorException;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.NounBaseEntity;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.InvalidParameterTypeException;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.views.adapters.ItemFilterAdapter;
import com.ds201625.fonda.views.adapters.RestaurantAdapter;
import com.ds201625.fonda.views.contracts.RestaurantsFiltersContract;
import java.util.List;

/**
 * Presentador controlador para vista / fragment de busqueda de restaurantes
 */
public class RestaurantsFilterPresenter {

    /**
     * Fragment con la implementacion del contrato
     */
    private RestaurantsFiltersContract fragment;

    /**
     * Tipo de filtro a mostrar
     */
    private RestaurantsFilterPresenterType type;

    /**
     * Adaptador para lista de restaurante
     */
    private RestaurantAdapter restaurantAdapter;

    /**
     * Adaptador para lista de items de filtro
     */
    private ItemFilterAdapter itemFilterAdapter;

    /**
     * Control de pagina de lista
     */
    private int restPage = 1;
    private int itemPage = 1;
    private boolean listFull = false;

    /**
     * Control de filtros
     */
    private int idZone= 0;
    private int idCat = 0;
    private String textSearch = null;

    /**
     * Control del adaptador que se muestra
     */
    private boolean showRestaurant;

    /**
     * Constructor del presentador para vista de filtros de restaurantes
     * @param fragment el fragment con la implementacion dela interfaz
     * @param type El tipo a mostrar (GENERAL, ZONE, CATEGORY)
     */
    public RestaurantsFilterPresenter
            (RestaurantsFiltersContract fragment, RestaurantsFilterPresenterType type) {
        this.fragment = fragment;
        this.type = type;
    }

    /**
     * Ejecutar en onCreateView del fragmente para inicializar los componentes
     */
    public void onCreateView() {

        // inicializacion de los adaptes
        if(this.restaurantAdapter == null)
            this.restaurantAdapter = new RestaurantAdapter(fragment.getContext());
        if(this.itemFilterAdapter == null)
            this.itemFilterAdapter = new ItemFilterAdapter(fragment.getContext());

        if (this.type == RestaurantsFilterPresenterType.GENERAL) {
            this.fragment.getListView().setAdapter(this.restaurantAdapter);
            this.fragment.setMultiSelect(true);
            this.showRestaurant = true;
        } else {
            this.fragment.getListView().setAdapter(this.itemFilterAdapter);
            this.fragment.setMultiSelect(false);
            this.showRestaurant = false;
        }

        onRefresh();
    }

    /**
     * Refresca / reinicia los adapters
     */
    public void onRefresh() {
        if (this.showRestaurant) {
            this.restaurantAdapter.clear();
            this.restPage = 1;
        } else {
            this.itemFilterAdapter.clear();
            this.itemPage = 1;
        }
        this.listFull = false;
        fillList();
    }

    /**
     * Accion de seleccionar un item
     * @param position posicion del item en la lista
     */
    public void onItemClick(int position) {
        Log.d("RestFilPresenter","Seleccionada posicion " + position + " de la lista.");


        if (this.showRestaurant) {
            // Si esta mostrando restaurantes se manda a abrir el activity de detalle
            this.fragment.openRestaurantActiviy((Restaurant) restaurantAdapter.getItem(position));
        } else {
            // Si no se obtiene la zona o categoria para aplicar filtro.
            int id = ((BaseEntity) itemFilterAdapter.getItem(position)).getId();
            this.textSearch = null;
            this.fragment.closeSearchView();

            switch (this.type) {
                case CATEGORY:
                    Log.d("RestFilPresenter",
                            "Seleccionada categoria id: " + id);
                    this.idCat = id;
                    break;

                case ZONE:
                    Log.d("RestFilPresenter",
                            "Seleccionada zona id: " + id);
                    this.idZone = id;
                    break;
                default:

                    break;
            }
            this.showRestaurant = true;
            this.fragment.getListView().setAdapter(this.restaurantAdapter);
            this.fragment.setMultiSelect(true);
            this.onRefresh();
        }
    }

    /**
     * Ejecutar cuando el listview esta al fondo
     */
    public void scrollOnBottom() {
        if(listFull)
            return;

        if (this.showRestaurant) {
            this.restPage++;
        } else {
            this.itemPage++;
        }
        fillList();
    }

    /**
     * Accion de actura del boton de atras
     * @return true si deja ejecutarse la accion por defecto
     */
    public boolean onBackPressed() {

        if (this.type != RestaurantsFilterPresenterType.GENERAL && this.showRestaurant) {
            this.fragment.setMultiSelect(false);
            this.fragment.getListView().setAdapter(this.itemFilterAdapter);
            this.showRestaurant = false;
            this.onRefresh();
            return false;
        }

        return true;
    }

    /**
     * Ejecutar el filtro de busqeda
     * @param text
     */
    public void search(String text) {
        this.textSearch = text;
        this.onRefresh();
    }

    /**
     * Llenado de lista
     */
    private void fillList() {

        Command cmd = null;

        fragment.setListViewEmtyType(RestaurantsFiltersContract.ListViewEmtyType.NORMAL);

        if (this.showRestaurant) {
            cmd = FondaCommandFactory.getInstance().getRestaurantsCommand();

            try {
                cmd.setParameter(0,this.textSearch);
                cmd.setParameter(1,6);
                cmd.setParameter(2,this.restPage);
                cmd.setParameter(4,this.idZone);
                cmd.setParameter(3,this.idCat);
            } catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.fragment.displayMsj("Error interno: " + e.getMessage());
                fragment.setListViewEmtyType(RestaurantsFiltersContract.ListViewEmtyType.NO_CONNECTION);
                return;
            }

            try {
                cmd.run();
            } catch (Exception e) {
                this.fragment.displayMsj("Error Al obtener los datos: " + e.getMessage());
                if (e.getClass() == RestClientException.class
                        || e.getClass() == ServerErrorException.class
                        || e.getClass() == UnknownServerErrorException.class )
                    fragment.setListViewEmtyType(RestaurantsFiltersContract.ListViewEmtyType.NO_CONNECTION);
                return;
            }

            if (cmd.getResult() != null) {
                if (((List<Restaurant>)cmd.getResult()).isEmpty())
                    this.listFull = true;
                else {
                    restaurantAdapter.addAll((List<Restaurant>) cmd.getResult());
                }
                this.restaurantAdapter.notifyDataSetChanged();
            }
            if (restaurantAdapter.isEmpty())
                fragment.setListViewEmtyType(RestaurantsFiltersContract.ListViewEmtyType.EMPTY);
        } else {
            switch (this.type) {
                case ZONE:
                    cmd = FondaCommandFactory.getInstance().getZonesCommand();
                    break;
                case CATEGORY:
                    cmd = FondaCommandFactory.getInstance().getCategoriesCommand();
                    break;
                default:

                    break;
            }

            try {
                cmd.setParameter(0,this.textSearch);
                cmd.setParameter(1,10);
                cmd.setParameter(2,this.itemPage);
            } catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.fragment.displayMsj("Error interno: " + e.getMessage());
                return;
            }

            try {
                cmd.run();
            } catch (Exception e) {
                this.fragment.displayMsj("Error Al obtener los datos: " + e.getMessage());
                if (e.getClass() == RestClientException.class
                        || e.getClass() == ServerErrorException.class
                        || e.getClass() == UnknownServerErrorException.class )
                    fragment.setListViewEmtyType(RestaurantsFiltersContract.ListViewEmtyType.NO_CONNECTION);
                return;
            }

            if (cmd.getResult() != null) {
                List<NounBaseEntity> list = (List<NounBaseEntity>) cmd.getResult();
                if (list.isEmpty()) {
                    this.listFull = true;
                } else {
                    this.itemFilterAdapter.addAll(list);
                }
                this.itemFilterAdapter.notifyDataSetChanged();
            }
            if (itemFilterAdapter.isEmpty())
                fragment.setListViewEmtyType(RestaurantsFiltersContract.ListViewEmtyType.EMPTY);
        }

    }

    /**
     * Colocar seleccionado un item
     * @param position
     * @param checked
     * @return
     */
    public int checkItem(int position,boolean checked) {
        this.restaurantAdapter.setSelectedItem(position,checked);
        return this.restaurantAdapter.countSelected();
    }

    /**
     * Accion de marcar como favoritos los seleccionados
     */
    public void favoriteMack() {
        int count = 0;
        for(Restaurant res : this.restaurantAdapter.getAllSeletedItems()) {
            if (res.getFavorite())
                continue;

            Command cmd = FondaCommandFactory.getInstance().getSetFabRestaurantCommand();

            try {
                cmd.setParameter(0,res.getId());
                cmd.setParameter(1,!res.getFavorite());
            } catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.fragment.displayMsj("Se ha producido un error interno en la aplicación " +
                "intente mas tarde.");
                e.printStackTrace();
                return;
            }

            try {
                cmd.run();
            } catch (Exception e) {
                if (e.getClass() == RestClientException.class
                        || e.getClass() == ServerErrorException.class
                        || e.getClass() == UnknownServerErrorException.class ) {
                    this.fragment.displayMsj("Se ha producido un error al conectarse con el servidor, " +
                            "intente mas tarde.");
                }
                e.printStackTrace();
                return;
            }
            count++;
        }
        this.fragment.displayMsj("Se han agregado " + count + " " +
                (count>1?" restaurantes":"restaurante") + " a sus favoritos.");
    }

    /**
     * limpiar los seleccionados
     */
    public void reset() {
        this.restaurantAdapter.cleanSelected();
    }

    /**
     * Enumerador para tipo de lsita
     */
    public enum RestaurantsFilterPresenterType {
        GENERAL,
        ZONE,
        CATEGORY
    }
}
