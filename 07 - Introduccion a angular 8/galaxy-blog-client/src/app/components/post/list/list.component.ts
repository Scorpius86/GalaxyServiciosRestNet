import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  posts:Post[]= new Array<Post>();

  constructor() { }

  ngOnInit() {

    for (let i = 0; i < 5; i++) {
      this.posts.push({
        PostId:i,
        Titulo:'Titulo-'+i.toString(),
        Contenido:'Contenido-'+i.toString()
      });
    }

  }

}
