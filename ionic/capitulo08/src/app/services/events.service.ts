import { Injectable } from '@angular/core';
import { Events } from '@ionic/angular';

@Injectable({
    providedIn: 'root'
  })
export class EventsService {
    public static clienteSelecionado: any;
    private static events: Events = new Events();

    /* constructor(
        private events: Events
    ) {
        console.log('criou service');
        // this.subscribeEvent();
    } */

    public static subscribeEvent(eventName: string) {
        console.log('inscrito');
        this.events.subscribe(eventName, (data) => {
            console.log('Enviou ', data);
            EventsService.clienteSelecionado = data;
        });
    }

    public static publishtoEvent(data: any) {
        console.log('publicando');
        this.events.publish('clienteSelecionado', data);
    }
}
