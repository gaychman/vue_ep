import Vue from 'vue';
import * as selection_types from './selection_types';

export class SelectionManager {
    constructor() {
        this.managed_objects = [];
        this.selected = [];
        this.event_bus = new Vue();

        this.event_bus.$on('selected', obj => {
            // гарантируем, что элемент не находится в массиве выбранных
            this.selected = this.selected.filter(item => item !== evt.target);

            this.selected.unshift(evt.target);

            this.set_state(this.selected[0], selection_types.PRIMARY);
            for (var i = 1; i < this.selected.length; i++) {
                this.set_state(this.selected[i], selection_types.SECONDARY);
            }
        });

        this.event_bus.$on('deselected', evt => {
            this.selected = this.selected.filter(item => item !== evt.target);
            this.event_bus.$emit("selection-changed", { target: evt.target, state: selection_types.NONE });
        });
    }

    set_state(obj, state) {
        if (obj.State !== state) {
            this.event_bus.$emit("selection-changed", { target: obj, state });
        }
    }

    register(obj) {
        this.managed_objects.push(obj);
    }

    deselectAll() {
        for (var i = 0; i < this.selected.length; i++) {
            this.selected[i].deselect();
        }
        this.selected = [];
    }

    get EventBus() {
        return this.event_bus;
    }
}