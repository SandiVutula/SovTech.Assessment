import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Joke } from './joke.model';

@Injectable({
  providedIn: 'root'
})

export class JokesService {

  private API_BASE_URL = 'https://localhost:7192/api/';

  constructor(
    private http: HttpClient
  ) { }

  //Get a list of available categories
  getCategories() {
    return this.http.get<string[]>(this.API_BASE_URL + 'jokes/categories'); 
  }

  //Get a random joke by category
  getRandomJokeByCategory(category: string) {
    return this.http.get<Joke>(this.API_BASE_URL + 'jokes/' + `random?category=${category}`); 
  }
}
