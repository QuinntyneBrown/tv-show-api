import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Episode } from "../models";
import { Observable } from "rxjs";
import { extractData } from "../utilities";

import { apiCofiguration } from "../configuration";


@Injectable()
export class EpisodeService {
    constructor(private _http: Http) { }

    public add(entity: Episode) {
        return this._http
            .post(`${apiCofiguration.baseUrl}/api/episode/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/episode/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/episode/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${apiCofiguration.baseUrl}/api/episode/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get baseUrl() { return apiCofiguration.baseUrl; }

}
