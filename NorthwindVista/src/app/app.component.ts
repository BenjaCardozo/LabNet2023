import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  longText = 'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illum dicta sunt, ratione consectetur in ipsum ex libero voluptatem amet sapiente odio quidem consequuntur debitis eum, aspernatur nesciunt sint cumque enim?';

  mostrar = true;
  frase: any = {
    mensaje: 'El Doc está vivo!',
    autor: 'Marty'
  }
  title = 'LabNet 2023';
}
