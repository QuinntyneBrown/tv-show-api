import { Action } from "@ngrx/store";
import { ADD_TV_SHOW_SUCCESS, GET_TV_SHOW_SUCCESS, REMOVE_TV_SHOW_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { TvShow } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const tvShowsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_TV_SHOW_SUCCESS:
            var entities: Array<TvShow> = state.tvShows;
            var entity: TvShow = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { tvShows: entities });

        case GET_TV_SHOW_SUCCESS:
            var entities: Array<TvShow> = state.tvShows;
            var newOrExistingTvShows: Array<TvShow> = action.payload;
            for (let i = 0; i < newOrExistingTvShows.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingTvShows[i] });
            }                                    
            return Object.assign({}, state, { tvShows: entities });

        case REMOVE_TV_SHOW_SUCCESS:
            var entities: Array<TvShow> = state.tvShows;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { tvShows: entities });

        default:
            return state;
    }
}

