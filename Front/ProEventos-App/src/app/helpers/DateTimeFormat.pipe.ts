import { DatePipe } from "@angular/common";
import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from "../utils/constants";

@Pipe({
  name: 'DateTimeFormatPipe', // Deve receber um nome diferente do da classe
  standalone: true,
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  override transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_TIME_FMT);
  }

}
