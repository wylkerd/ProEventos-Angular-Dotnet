import { DatePipe } from "@angular/common";
import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from "../utils/constants";

@Pipe({
  name: 'DateTimeFormatPipe', // Deve receber um nome diferente do da classe
  standalone: true,
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  override transform(value: any, args?: any): any {
    // Convert the date string to a format recognized by JavaScript (e.g., "YYYY-MM-DDTHH:mm:ss")
    const formattedDateString = value.replace(/(\d{2})\/(\d{2})\/(\d{4}) (\d{2}:\d{2}:\d{2})/, '$3-$2-$1T$4');
    const parsedDate = new Date(formattedDateString);

    return super.transform(parsedDate, Constants.DATE_TIME_FMT);
  }

}
