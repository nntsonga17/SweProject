export const isActiveClass = (isTrushy, defaultClass) => {
  if (!defaultClass) defaultClass = '';

  return isTrushy ? `${defaultClass} active` : defaultClass;
};
