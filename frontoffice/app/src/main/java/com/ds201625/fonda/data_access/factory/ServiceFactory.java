package com.ds201625.fonda.data_access.factory;


import com.ds201625.fonda.data_access.services.*;

/**
 * Created by rrodriguez on 5/7/16.
 */
public interface ServiceFactory {

    ProfileService getProfileService();

}