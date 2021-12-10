package io.ionic.starter;

import com.hemangkumar.capacitorgooglemaps.CapacitorGoogleMaps;
import com.getcapacitor.BridgeActivity;
import android.os.Bundle;


public class MainActivity extends BridgeActivity {
    @Override
    public void onCreate(Bundle savedInstanceState) {
      super.onCreate(savedInstanceState);
      registerPlugin(CapacitorGoogleMaps.class);
    }
}
