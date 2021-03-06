package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.CommandInternalErrorException;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para crear un Commensal
 */
public class CreateCommensalCommand extends BaseCommand {

    private String TAG = "CreateCommensalCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro email y password
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[3];
        parameters[0] = new Parameter(String.class, true);
        parameters[1] = new Parameter(String.class, true);
        parameters[2] = new Parameter(Context.class, true);

        return parameters;
    }

    @Override
    protected void invoke() throws Exception{

        Log.d(TAG, "Comando para agregar un commensal");
        String email;
        String password;
        Context context;
        Commensal commensal = null;

        CommensalService commensalService = FondaServiceFactory.getInstance().getCommensalService();
        try
        {
            email = (String) getParameter(0);
            password = (String) getParameter(1);
            context = (Context) getParameter(2);
            commensal = commensalService.RegisterCommensal(email,password,context);
            Log.d(TAG, "Se agrego el Commensal id: " + commensal.getId() +
                    " email: " + commensal.getEmail());
        }
        catch (ParameterOutOfIndexException e) {
            Log.e("Fonda Command",e.getMessage());
            throw CommandInternalErrorException.generate(this.getClass().toString(),e);
        }

        setResult(commensal);
        Log.d(TAG, "Se agrego con exito el Commensal. Result: " + getResult().toString());
        Log.d(TAG, "Se agrego con exito el Commensal");
    }
}
