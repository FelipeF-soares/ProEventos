import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
private isCollapsed : boolean = false;
public eventos: any;
public widthImg: number = 150;
public marginImg: number = 2;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  private getEventos(){
    this.http.get('https://localhost:5001/api/eventos').subscribe(
        response=> this.eventos = response,
        error=> console.log(error)
    );
  }

  public setCollapsed(){
    this.isCollapsed = !this.isCollapsed;
  }

  public getCollapsed(){
    return this.isCollapsed;
  }
}
