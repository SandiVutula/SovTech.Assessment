import { Component, OnInit } from '@angular/core';
import { JokesService } from './jokes.service';

import { Joke } from './joke.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  jokes: any[] = [];
  categories: string[] = [];

  constructor(
    private jokesService: JokesService
  ) {}
  
  // Load list of categories for UI
  ngOnInit () {
    this.jokesService.getCategories()
    .subscribe((categories: string[]) => {
      this.categories = categories;
    });
  }

  //Display random joke when category is clicked 
  displayJokeByCategory(category: string) {
    this.jokesService.getRandomJokeByCategory(category)
    .subscribe((joke: Joke) => {
      this.jokes = [];
      this.jokes.push(joke);
    });
  }
}
