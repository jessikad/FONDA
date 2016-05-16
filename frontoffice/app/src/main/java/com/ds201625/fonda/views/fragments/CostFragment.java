package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.DialogFragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.activities.FilterList;

/**
 * Created by Valentina on 17/04/2016.
 */
public class CostFragment extends BaseFragment {

    ListView list;

    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View view= inflater.inflate(R.layout.fragment_cost,container,false);

        /*FilterList adapter = new
                FilterList(getActivity(),location);
        list=(ListView)view.findViewById(R.id.listViewRestaurants);
        list.setAdapter(adapter);*/

       /* DialogFragment dialog = new TwoActionButtonsDialog();
        dialog.show(getSupportFragmentManager(), "dialog");*/

        return view;

    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }



}

