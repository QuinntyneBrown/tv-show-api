import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { SeasonService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_SEASON_SUCCESS, GET_SEASON_SUCCESS, REMOVE_SEASON_SUCCESS } from "../constants";
import { Season } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class SeasonActions {
    constructor(private _seasonService: SeasonService, private _store: AppStore) { }

    public add(season: Season) {
        const newGuid = guid();
        this._seasonService.add(season)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_SEASON_SUCCESS,
                    payload: season
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._seasonService.get()
            .subscribe(seasons => {
                this._store.dispatch({
                    type: GET_SEASON_SUCCESS,
                    payload: seasons
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._seasonService.remove({ id: options.id })
            .subscribe(season => {
                this._store.dispatch({
                    type: REMOVE_SEASON_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._seasonService.getById({ id: options.id })
            .subscribe(season => {
                this._store.dispatch({
                    type: GET_SEASON_SUCCESS,
                    payload: [season]
                });
                return true;
            });
    }
}
