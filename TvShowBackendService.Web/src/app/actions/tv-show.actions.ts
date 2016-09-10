import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { TvShowService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_TV_SHOW_SUCCESS, GET_TV_SHOW_SUCCESS, REMOVE_TV_SHOW_SUCCESS } from "../constants";
import { TvShow } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class TvShowActions {
    constructor(private _tvShowService: TvShowService, private _store: AppStore) { }

    public add(tvShow: TvShow) {
        const newGuid = guid();
        this._tvShowService.add(tvShow)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_TV_SHOW_SUCCESS,
                    payload: tvShow
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._tvShowService.get()
            .subscribe(tvShows => {
                this._store.dispatch({
                    type: GET_TV_SHOW_SUCCESS,
                    payload: tvShows
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._tvShowService.remove({ id: options.id })
            .subscribe(tvShow => {
                this._store.dispatch({
                    type: REMOVE_TV_SHOW_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._tvShowService.getById({ id: options.id })
            .subscribe(tvShow => {
                this._store.dispatch({
                    type: GET_TV_SHOW_SUCCESS,
                    payload: [tvShow]
                });
                return true;
            });
    }
}
