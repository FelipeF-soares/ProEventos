import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

private isCollapsed : boolean = false;
public eventos: any = [];
public eventosOfFilter: any = [];
public widthImg: number = 150;
public marginImg: number = 2;
public _filterList: string = '';

public get filterList() : string{
  return this._filterList;
}

public set filterList(value: string){
  this._filterList = value;
  this.eventosOfFilter = this.filterList ? this.filterEventos(this.filterList) : this.eventos;
}

filterEventos(filterOf : string): any {
  filterOf = filterOf.toLocaleLowerCase();
  return this.eventos.filter(
    (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filterOf) !== -1 ||
    evento.local.toLocaleLowerCase().indexOf(filterOf) !== -1
  )
}
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  private getEventos(){
    this.http.get('https://localhost:5001/api/eventos').subscribe(
        response=> {
          this.eventos = response;
          this.eventosOfFilter = this.eventos;
        },
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
