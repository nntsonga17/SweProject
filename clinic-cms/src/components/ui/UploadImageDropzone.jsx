import { TrashIcon } from '../../assets/icons/TrashIcon';
import { useRef, useState } from 'react';

export const UploadImageDropzone = ({ defaultImage, onUpload, onClear }) => {
  const [file, setFile] = useState(null);

  const inputRef = useRef(null);

  const onChange = (e) => {
    const sFile = e.target.files?.[0];
    if (!sFile) return;

    setFile(URL.createObjectURL(sFile));
    onUpload(sFile);
  };

  const clearImage = () => {
    setFile(null);
    inputRef.current.value = null;
    onClear();
  };

  return (
    <div className="uploadImageDropzone">
      {file ? (
        <>
          <button type="button" onClick={clearImage}>
            <TrashIcon />
          </button>
          <img src={file} alt="Uploaded" />
        </>
      ) : defaultImage ? (
        <img src={defaultImage} alt="Uploaded" />
      ) : (
        <p>Upload image</p>
      )}
      <input type="file" onChange={onChange} ref={inputRef} />
    </div>
  );
};
