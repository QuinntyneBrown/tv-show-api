import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { EpisodeService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_EPISODE_SUCCESS, GET_EPISODE_SUCCESS, REMOVE_EPISODE_SUCCESS } from "../constants";
import { Episode } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class EpisodeActions {
    constructor(private _episodeService: EpisodeService, private _store: AppStore) { }

    public add(episode: Episode) {
        const newGuid = guid();
        this._episodeService.add(episode)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_EPISODE_SUCCESS,
                    payload: episode
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._episodeService.get()
            .subscribe(episodes => {
                this._store.dispatch({
                    type: GET_EPISODE_SUCCESS,
                    payload: episodes
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._episodeService.remove({ id: options.id })
            .subscribe(episode => {
                this._store.dispatch({
                    type: REMOVE_EPISODE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._episodeService.getById({ id: options.id })
            .subscribe(episode => {
                this._store.dispatch({
                    type: GET_EPISODE_SUCCESS,
                    payload: [episode]
                });
                return true;
            });
    }
}
