import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { DigitalAssetService } from "../services";
import { AppState, AppStore } from "../store";
import { ADD_DIGITAL_ASSET_SUCCESS, GET_DIGITAL_ASSET_SUCCESS, REMOVE_DIGITAL_ASSET_SUCCESS } from "../constants";
import { DigitalAsset } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class DigitalAssetActions {
    constructor(private _digitalAssetService: DigitalAssetService, private _store: AppStore) { }

    public add(digitalAsset: DigitalAsset) {
        const newGuid = guid();
        this._digitalAssetService.add(digitalAsset)
            .subscribe(book => {
                this._store.dispatch({
                    type: ADD_DIGITAL_ASSET_SUCCESS,
                    payload: digitalAsset
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._digitalAssetService.get()
            .subscribe(digitalAssets => {
                this._store.dispatch({
                    type: GET_DIGITAL_ASSET_SUCCESS,
                    payload: digitalAssets
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._digitalAssetService.remove({ id: options.id })
            .subscribe(digitalAsset => {
                this._store.dispatch({
                    type: REMOVE_DIGITAL_ASSET_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._digitalAssetService.getById({ id: options.id })
            .subscribe(digitalAsset => {
                this._store.dispatch({
                    type: GET_DIGITAL_ASSET_SUCCESS,
                    payload: [digitalAsset]
                });
                return true;
            });
    }
}
