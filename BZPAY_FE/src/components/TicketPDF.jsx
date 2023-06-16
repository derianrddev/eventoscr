import { Document, Page, Text, View, StyleSheet } from "@react-pdf/renderer";
import { formatDate } from "../helpers";

export const TicketPDF = ({ ticket }) => {
  return (
    <Document>
      <Page style={styles.page}>
        <View style={styles.container}>
          <Text style={styles.title}>Factura de pago</Text>
          <Text>Id de compra: {ticket.id}</Text>
          <Text>Cantidad de entradas: {ticket.cantidad}</Text>
          <Text>Fecha de reserva: {formatDate(ticket.fechaReserva)}</Text>
          <Text>Fecha de pago: {formatDate(ticket.fechaPago)}</Text>
          <Text style={styles.sectionTitle}>Detalles del evento</Text>
          <Text>Nombre del evento: {ticket.evento}</Text>
          <Text>Descripción del evento: {ticket.tipoEvento}</Text>
          <Text>Escenario: {ticket.escenario}</Text>
          <Text style={styles.sectionTitle}>Detalles de la entrada</Text>
          <Text>Tipo de asiento: {ticket.tipoAsiento}</Text>
          <Text>Precio por entrada: {ticket.precio}</Text>
          <Text style={[styles.sectionTitle, styles.textEnd]}>Total: {ticket.total}</Text>
        </View>
      </Page>
    </Document>
  );
};

const styles = StyleSheet.create({
  page: {
    fontFamily: "Helvetica",
    fontSize: 12,
    padding: 40,
    lineHeight: 1.5,
  },
  container: {
    marginBottom: 20,
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 20,
    textAlign: "center",
  },
  sectionTitle: {
    fontSize: 16,
    fontWeight: "bold",
    marginTop: 20,
  },
  textEnd: {
    textAlign: "right"
  },
});
