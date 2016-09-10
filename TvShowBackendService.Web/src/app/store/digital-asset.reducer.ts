import { Action } from "@ngrx/store";
import { ADD_DIGITAL_ASSET_SUCCESS, GET_DIGITAL_ASSET_SUCCESS, REMOVE_DIGITAL_ASSET_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { DigitalAsset } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const digitalAssetsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_DIGITAL_ASSET_SUCCESS:
            var entities: Array<DigitalAsset> = state.digitalAssets;
            var entity: DigitalAsset = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { digitalAssets: entities });

        case GET_DIGITAL_ASSET_SUCCESS:
            var entities: Array<DigitalAsset> = state.digitalAssets;
            var newOrExistingDigitalAssets: Array<DigitalAsset> = action.payload;
            for (let i = 0; i < newOrExistingDigitalAssets.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingDigitalAssets[i] });
            }                                    
            return Object.assign({}, state, { digitalAssets: entities });

        case REMOVE_DIGITAL_ASSET_SUCCESS:
            var entities: Array<DigitalAsset> = state.digitalAssets;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { digitalAssets: entities });

        default:
            return state;
    }
}

