package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AlertDialog;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.CurrentOrderFragment;

public class CierreCuentaActivity extends BaseNavigationActivity {

    private CloseAccountFragment closeAccFrag;

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    private MenuItem sendBotton;
    private MenuItem cancelBotton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_cierre_cuenta);
        super.onCreate(savedInstanceState);

        closeAccFrag = new CloseAccountFragment();

        fm = getSupportFragmentManager();

        //Lanzamiento de closeAccFrag como el principal
        fm.beginTransaction()
                .replace(R.id.fragment_container2,closeAccFrag)
                .commit();

        // Asegura que almenos onCreate se ejecuto en el fragment
        fm.executePendingTransactions();

    }


    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.close2, menu);
        sendBotton = menu.findItem(R.id.action_favorite_send);
        cancelBotton = menu.findItem(R.id.action_favorite_cancel);

        return true;
    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_favorite_send:
                pagar();
                break;
            case R.id.action_favorite_cancel:
                cancelar();
                break;
        }
        return true;
    }

    private void pagar() {
      //  AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
       //         "Se puede proceder con el cierre.");
      //  dialog.show();

        cambiarPa();
    }


    private void cancelar() {
        //  AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
        //         "Se puede proceder con el cierre.");
        //  dialog.show();

        cambiarO ();
    }

    public void cambiarPa ()
    {
        Intent cambio = new Intent (this,PagoOrdenActivity.class);
        startActivity(cambio);
    }

    public void cambiarO ()
    {
        Intent cambio = new Intent (this,OrdersActivity.class);
        startActivity(cambio);
    }
}
