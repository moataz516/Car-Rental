import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import WebViewer from '@pdftron/webviewer';
import jsPDF from 'jspdf';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';

pdfMake.vfs = pdfFonts.pdfMake.vfs;



@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit, AfterViewInit {
resInfo:any;
pdfUrl:string='';
@ViewChild('viewer') viewerRef: ElementRef;
constructor(private route:ActivatedRoute, private dataPipe:DatePipe ){}
ngOnInit(): void {
 this.resInfo =  this.route.snapshot.data.data;
 console.log(this.resInfo)
}


formatDate(date:string):string{
  return this.dataPipe.transform(date,'yyyy-MM-dd') || ';'
}



ngAfterViewInit(): void {
  // WebViewer({
  //   path:'../../../../../assets/lib',
  //   initialDoc:''
  // },this.viewerRef.nativeElement)
}




generatePDF() {
  const documentDefinition = {
    content: [
      {
        text: 'Your Reservation Details',
        style: 'header'
      },
      {
        columns: [
          {
            width: '50%',
            text: 'Reference ID:\nStatus:\nType:\nStart Date:\nEnd Date:\nPick up location:\nReturn location:',
            style: 'infoLabels'
          },
          {
            width: '50%',
            text: `${this.resInfo.reservationId}\n${this.resInfo.status}\n${this.resInfo.car.vehicleType.typeName}:${this.resInfo.car.vehicleType.vehicleClass}\n${this.formatDate(this.resInfo.startDate)}\n${this.formatDate(this.resInfo.endDate)}\n${this.resInfo.startLocation}\n${this.resInfo.endLocation}`,
            style: 'infoData'
          },


        ],
        style: 'info'
      },
      {
        columns: [
          {
            width: '50%',
            text: 'Reference ID:\nStatus:\nType:\nStart Date:\nEnd Date:\nPick up location:\nReturn location:',
            style: 'infoLabels'
          },
          {
            width: '50%',
            text: `${this.resInfo.reservationId}\n${this.resInfo.status}\n${this.resInfo.car.vehicleType.typeName}:${this.resInfo.car.vehicleType.vehicleClass}\n${this.formatDate(this.resInfo.startDate)}\n${this.formatDate(this.resInfo.endDate)}\n${this.resInfo.startLocation}\n${this.resInfo.endLocation}`,
            style: 'infoData2'
          },


        ],
        style: 'info2'
      }
    ],
    styles: {
      header: {
        fontSize: 16,
        bold: true,
        margin: [0, 0, 0, 10]
      },
      info: {
        fontSize: 14,
        margin: [ 0,0,0,100]
      },
      infoLabels: {
        bold: true
      },
      infoData: {
      }
    }
  };
console.log(documentDefinition)
  pdfMake.createPdf(documentDefinition).open();
}

formatDatee(date: Date): string {
  // Implement your date formatting logic here
  return date.toISOString();
}






// generatePDF() {
//   // Define the content for the PDF
//   pdfMake.vfs = pdfFonts.pdfMake.vfs;

//   const content = [
//     {
//       text: 'Your reservation details',
//       style: 'header'
//     },
//     {
//       columns: [
//         {
//           text: 'Reference ID',
//           style: 'subheader'
//         },
//         {
//           text: this.resInfo.reservationId
//         }
//       ]
//     },
//     {
//       columns: [
//         {
//           text: 'Status',
//           style: 'subheader'
//         },
//         {
//           text: this.resInfo.status,
//           style: 'successBadge' // Define a custom style for the success badge
//         }
//       ]
//     },
//     // Add more sections for other reservation details
//   ];

//   // Define custom styles
//   const styles = {
//     header: {
//       fontSize: 18,
//       bold: true
//     },
//     subheader: {
//       fontSize: 14,
//       bold: true
//     },
//     successBadge: {
//       background: 'green',
//       color: 'white'
//     }
//   };

//   // Create the PDF document
//   const docDefinition = {
//     content,
//     styles
//   };

//   pdfMake.vfs = pdfFonts.pdfMake.vfs;
//   pdfMake.createPdf(docDefinition).open(); // Open the PDF in a new tab
// }


}
