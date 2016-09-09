import { Action } from "@ngrx/store";
import { ADD_SEASON_SUCCESS, GET_SEASON_SUCCESS, REMOVE_SEASON_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Season } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const seasonsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_SEASON_SUCCESS:
            var entities: Array<Season> = state.seasons;
            var entity: Season = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { seasons: entities });

        case GET_SEASON_SUCCESS:
            var entities: Array<Season> = state.seasons;
            var newOrExistingSeasons: Array<Season> = action.payload;
            for (let i = 0; i < newOrExistingSeasons.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingSeasons[i] });
            }                                    
            return Object.assign({}, state, { seasons: entities });

        case REMOVE_SEASON_SUCCESS:
            var entities: Array<Season> = state.seasons;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { seasons: entities });

        default:
            return state;
    }
}

