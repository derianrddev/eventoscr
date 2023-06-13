
export const formatDate = (unformattedDate) => {
  const date = new Date(unformattedDate);
  const day = date.getDate();
  const month = date.getMonth() + 1;
  const year = date.getFullYear();

  // Formatear la fecha como "DD/MM/YYYY"
  const formattedDate = `${day < 10 ? "0" + day : day}/${
    month < 10 ? "0" + month : month
  }/${year}`;

  return formattedDate;
};