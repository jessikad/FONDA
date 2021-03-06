package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.InvalidParameterTypeException;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.views.contracts.ProfileListViewContract;
import com.ds201625.fonda.views.contracts.ProfileViewContract;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import java.util.List;

/**
 * Created by jessi_ds930h9 on 22/6/2016.
 */
public class ProfilePresenter{

    private ProfileListViewContract profileListView;
    private ProfileViewContract profileView;
    private String TAG = "ProfilePresenter";
    /**
     * Constructor para la vita de ProfileListFraggment
     * @param view
     */
    public ProfilePresenter (ProfileListViewContract view){ profileListView = view;}

    /**
     * Constructor para la vita de ProfileActivity
     * @param view
     */
    public ProfilePresenter (ProfileViewContract view){ profileView = view;}

    /**
     * Metodo encargado de Crear perdil
     * @param profile que se desea crear
     * @return True si se crea de forma correcta,false en caso contrario
     */
        public Boolean createProfile(Profile profile) {
            Log.d(TAG,"Metodo createProfile");
            Boolean resp = false;
            try {
                Command commandoCreateProfile = FondaCommandFactory.createProfileCommand();
                commandoCreateProfile.setParameter(0, profile);
                commandoCreateProfile.run();
                resp = (boolean) commandoCreateProfile.getResult();
                this.profileView.displayMsj("Se agrego con Exito!!");
            }
            catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.profileView.displayMsj("Error interno: " + e.getMessage());
            }
            catch (Exception e)
            {
                Log.e(TAG,"Error al crear Perfil",e);
                this. profileView.displayMsj(e.getMessage());
            }
            Log.d(TAG,"Cierre del Metodo createProfile");
            return resp;
        }

    /**
     * Metodo Encargado de actualizar perfil
     * @param profile
     * @return True en caso de exito,false en caso contrario
     */
        public Boolean updateProfile(Profile profile) {
            Log.d(TAG,"Metodo updateProfile");
            Boolean resp = false;
            try {
                Command commandoUpdateProfile = FondaCommandFactory.updateProfileCommand();
                commandoUpdateProfile.setParameter(0,profile);
                commandoUpdateProfile.run();
                resp = (boolean) commandoUpdateProfile.getResult();
                this.profileView.displayMsj("Se modifico con Exito!!");
            }
            catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.profileView.displayMsj("Error interno: " + e.getMessage());
            } catch (Exception e)
            {
                Log.e(TAG,"Error al modificar Perfil",e);
                this. profileView.displayMsj(e.getMessage());
            }
            Log.d(TAG,"Cierre del Metodo updateProfile");
            return resp;
        }

    /**
     * Metodo encargado de eliminar Perfil
     * @param profile
     * @return True en caso de eliminar con exito,false en caso contrario
     */
        public Boolean deleteProfile(Profile profile) {
            Log.d(TAG,"Metodo deleteProfile");
            Boolean resp = false;
            try {
                Command commandoDeleteProfile = FondaCommandFactory.
                        deleteProfileCommand();
                commandoDeleteProfile.setParameter(0,profile);
                commandoDeleteProfile.run();
                resp = (boolean) commandoDeleteProfile.getResult();
                this.profileView.displayMsj("Se elimino con Exito!!");
            }
            catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.profileView.displayMsj("Error interno: " + e.getMessage());
            }
            catch (Exception e)
            {
                Log.e(TAG,"Error al eliminar el Perfil",e);
                this. profileView.displayMsj(e.getMessage());
            }
            Log.d(TAG,"Cierre del Metodo deleteProfile");
            return resp;
        }

    /**
     * Metodo encargado de buscar la lista de perfiles de comensal
     * @return List<Profile>
     */
        public List<Profile> getProfiles() {
            Log.d(TAG,"Metodo getProfiles");
            List<Profile> resp = null;
            try {
                Command commandoGetProfiles = FondaCommandFactory.getProfilesCommand();
                commandoGetProfiles.run();
                resp = (List<Profile>) commandoGetProfiles.getResult();
            }
            catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.profileView.displayMsj("Error interno: " + e.getMessage());
            } catch (Exception e)
            {
                Log.e(TAG,"Error al Listar los Perfiles",e);
                this. profileView.displayMsj(e.getMessage());
            }
            Log.d(TAG,"Cierre del Metodo getProfiles");
            return resp;
        }

}
