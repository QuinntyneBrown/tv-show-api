import { Action } from "@ngrx/store";
import { ADD_EPISODE_SUCCESS, GET_EPISODE_SUCCESS, REMOVE_EPISODE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Episode } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const episodesReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case ADD_EPISODE_SUCCESS:
            var entities: Array<Episode> = state.episodes;
            var entity: Episode = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { episodes: entities });

        case GET_EPISODE_SUCCESS:
            var entities: Array<Episode> = state.episodes;
            var newOrExistingEpisodes: Array<Episode> = action.payload;
            for (let i = 0; i < newOrExistingEpisodes.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingEpisodes[i] });
            }                                    
            return Object.assign({}, state, { episodes: entities });

        case REMOVE_EPISODE_SUCCESS:
            var entities: Array<Episode> = state.episodes;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { episodes: entities });

        default:
            return state;
    }
}

