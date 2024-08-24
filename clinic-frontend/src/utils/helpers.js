export const isActiveClass = (isTrushy, defaultClass) => {
  if (!defaultClass) defaultClass = "";
  return isTrushy ? `${defaultClass} active` : defaultClass;
};

export const formatPrice = (price) =>
  price.toLocaleString("sr-RS", {
    style: "currency",
    currency: "RSD",
    minimumFractionDigits: 2,
  });
