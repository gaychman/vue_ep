import * as selection_types from './selection_types';

export class Selectable {
    constructor(obj, event_bus) {
        this.event_bus = event_bus;
        this.obj = obj;
        this.state = selection_types.NONE;

        this.event_bus.$on('selection-changed', evt => {
            if (this === evt.target) {
                this.state = evt.state;
            }
        });
    }

    select(keep) {
        this.event_bus.$emit('selected', { target: this, keep });
    }

    deselect() {
        this.event_bus.$emit('deselected', { target: this });
    }

    get EventBus() {
        return this.event_bus;
    }

    get State() {
        return this.state;
    }
}