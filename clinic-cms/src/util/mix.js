export const formatPrice = (price) =>
  price.toLocaleString('sr-RS', {
    style: 'currency',
    currency: 'RSD',
    minimumFractionDigits: 2,
  });
